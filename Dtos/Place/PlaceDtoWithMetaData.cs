using PlayNirvanaTechExam.RequestFeatures;

namespace PlayNirvanaTechExam.Dtos.Place;

public record PlaceDtoWithMetaData(IEnumerable<PlaceResponse> Places, MetaData MetaData);