﻿namespace SoundFingerprinting.Query
{
    using System.Collections.Generic;
    using System.Linq;

    public class QueryResult
    {
        /// <summary>
        ///  Create an instance of QueryResult class
        /// </summary>
        /// <param name="results">Actual result entries</param>
        public QueryResult(IEnumerable<ResultEntry> results)
        {
            ResultEntries = results;
        }

        /// <summary>
        ///   Gets a value indicating whether query result contains any matches
        /// </summary>
        public bool ContainsMatches => ResultEntries != null && ResultEntries.Any();

        /// <summary>
        ///   Gets the list of matches, sorted from the most probable to the least probable
        /// </summary>
        public IEnumerable<ResultEntry> ResultEntries { get; }

        /// <summary>
        ///  Gets best match if result entries are not empty
        /// </summary>
        public ResultEntry BestMatch => ContainsMatches ? ResultEntries.First() : null;

        /// <summary>
        ///  Gets query statistics
        /// </summary>
        public QueryStats Stats { get; } = new QueryStats();

        /// <summary>
        ///  Returns empty query result
        /// </summary>
        public static QueryResult Empty { get; } = new QueryResult(Enumerable.Empty<ResultEntry>());

        /// <summary>
        ///  Returns an instance of QueryResult class that will contain a list of result entries
        /// </summary>
        /// <param name="results">Result entries</param>
        /// <param name="totalTracksCandidates">Total track candidates analyzed during query</param>
        /// <param name="totalSubFingerprintCandidates">Total sub-fingerprint candidates analyzed during query</param>
        /// <returns>Instance of QueryResult class</returns>
        public static QueryResult NonEmptyResult(IEnumerable<ResultEntry> results, int totalTracksCandidates, int totalSubFingerprintCandidates)
        {
            var queryResults = new QueryResult(results)
                               {
                                   Stats =
                                   {
                                       TotalTracksAnalyzed = totalTracksCandidates,
                                       TotalFingerprintsAnalyzed = totalSubFingerprintCandidates
                                   }
                               };
            return queryResults;
        }
    }
}
